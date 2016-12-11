using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRPLNiwatori.Models;

namespace WebRPLNiwatori.DAL
{
    public class Master_KecamatanDAL : IDisposable
    {
        private NiwatoriModelsss db = new NiwatoriModelsss();

        public IQueryable<Master_Kecamatan> GetDataKec()
        {
            var results = from c in db.Master_Kecamatan
                          select c;
            return results;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}