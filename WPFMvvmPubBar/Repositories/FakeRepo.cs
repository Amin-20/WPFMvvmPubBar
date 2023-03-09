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
                    Name="Xirdalan",
                    Price=2.20,
                    Volume=4.8,
                    ImagePath="/Images/xirdalan.png"
                },
                new Beer
                {
                    Name="NZS",
                    Price=1.95,
                    Volume=10,
                    ImagePath="/Images/Nzs.jpg"
                },
                new Beer
                {
                    
                }

            };
        }
    }
}
