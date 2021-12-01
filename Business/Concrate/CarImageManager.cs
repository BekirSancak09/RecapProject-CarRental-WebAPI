using Business.Abstract;
using Business.Constans;
using Core.Aspects.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Uploads.FileHelper;
using DataAccess.Abstract;
using Entities.Concrate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrate
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carDal)
        {
            _carImageDal = carDal;
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }

            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = 0, ImageId = 0, ImagePath = "/Images/mslogo.png" });

            return new SuccessDataResult<List<CarImage>>(images);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.ImageId == id));
        }

        public IResult Add(IFormFile image, CarImage carImage)
        {

            var imageCount = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult("One car must have 5 or less images");
            }

            var imageResult = FileHelper.Upload(image);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;

            _carImageDal.Add(carImage);
            return new SuccessResult("Car image added");
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.ImageId == carImage.ImageId);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            FileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Image was deleted successfully");
        }

        public IResult Update(IFormFile image, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.ImageId == carImage.ImageId);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileHelper.Update(image, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult("Car image updated");

        }

    }
}
