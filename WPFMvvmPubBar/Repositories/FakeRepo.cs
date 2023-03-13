using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMvvmPubBar.Models;

namespace WPFMvvmPubBar.Repositories
{
    public class FakeRepo
    {
        public List<Beer> GetAll()
        {
            return new List<Beer>
            {
                new Beer
                {
                    Id=1,
                    Name="Xirdalan",
                    Price=2.20,
                    Volume=4.8,
                    ImagePath="/Images/Xirdalan.png"
                },
                new Beer
                {
                    Id =2,
                    Name="NZS",
                    Price=1.95,
                    Volume=3.5 ,
                    ImagePath="/Images/Nzs.jpg"
                },
                new Beer
                {
                    Id=3,
                    Name="Efes",
                    Price=1.9,
                    Volume=4.5,
                    ImagePath="/Images/Efes.png"
                },
                new Beer
                {
                    Id=4,
                    Name="Efsane",
                    Price=3 ,
                    Volume=4.7,
                    ImagePath="/Images/Efsane.jpg"
                }
            };
        }
    }
}