﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carstore.Model
{
    public class CarTableModel
    {

        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int Power { get; set; }
        public string Seller { get; set; }

        public CarTableModel()
        {
            Id = 0;
            Photo = new byte[0];
            Mark = "";
            Model = "";
            Color = "";
            Price = 0;
            Power = 0;
            Seller = "";
        }

        public CarTableModel(int id, byte[] photo, string mark, string model, string color, int price, int power, string seller)
        {
            Id = id;
            Photo = photo;
            Mark = mark;
            Model = model;
            Color = color;
            Price = price;
            Power = power;
            Seller = seller;
        }

        public CarTableModel(CarPurpose purpose)
        {
            Id = purpose.Id;
            Photo = purpose.Car.CarPhoto.First().Photo.Data;
            Mark = purpose.Car.CarModel.CarMark.Name;
            Model = purpose.Car.CarModel.Name;
            Color = purpose.Car.Color;
            Price = purpose.Car.Price;
            Power = purpose.Car.Power;
            Seller = $"{purpose.User.Firstname} {purpose.User.Lastname}";
        }

    }
}
