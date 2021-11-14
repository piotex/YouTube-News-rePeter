using KotGospodarczy.MyCode.v1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KotGospodarczy.MyCode.v1.Interfaces
{
    public interface INewsManager
    {
        public List<ModelNews> GetNewsList();
        public string GetUrl();
    }
}
