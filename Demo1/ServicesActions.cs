using Demo1.ContextFolder;
using Demo1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    public static class ServicesActions
    {
        public static bool IsAdmin = false;
        public static IsajkinContext DBContext { get; set; } = new IsajkinContext();
        public static List<Service> ListServices = DBContext.Services.ToList();
        public static string ShowmAmount = $"{ListServices.Count}/{DBContext.Services.ToList().Count()}";
        public static void Fill()
        {
            ListServices = DBContext.Services.ToList();
        }
        public static void SomethingChanged(string str, int sort, int filtr)
        {
            ListServices = DBContext.Services.ToList();
            switch (sort)
            {
                case 1:
                    ListServices = ListServices.OrderByDescending(p => p.CostWithDiscount).ToList();
                    break;
                case 2:
                    ListServices = ListServices.OrderBy(p => p.CostWithDiscount).ToList();
                    break;
            }
            switch (filtr)
            {
                case 1:
                    ListServices = ListServices.Where(s => s.Discount < 0.05).ToList();
                    break;
                case 2:
                    ListServices = ListServices.Where(s => s.Discount >= 0.05 && s.Discount < 0.15).ToList();
                    break;
                case 3:
                    ListServices = ListServices.Where(s => s.Discount >= 0.15 && s.Discount < 0.30).ToList();
                    break;
                case 4:
                    ListServices = ListServices.Where(s => s.Discount >= 0.30 && s.Discount < 0.70).ToList();
                    break;
                case 5:
                    ListServices = ListServices.Where(s => s.Discount >= 0.70).ToList();
                    break;

            }
            ListServices = ListServices.Where(s => s.Title.ToLower().Contains(str.ToLower())).ToList();

            ShowmAmount = $"{ListServices.Count}/{DBContext.Services.ToList().Count()}";
        }
    }
}
