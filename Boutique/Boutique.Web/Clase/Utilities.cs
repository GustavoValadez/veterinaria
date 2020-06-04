using Boutique.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boutique.Web.Clase
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();





        public void Dispose()
        {
            db.Dispose();
        }
    }
}