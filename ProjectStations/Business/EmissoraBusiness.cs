using ProjectStations.ADO;
using ProjectStations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStations.Business
{
    public class EmissoraBusiness
    {
        ProjectStationsEntities _db = new ProjectStationsEntities();
        public EmissoraBusiness()
        {
        }

        public void AddEmissoras(ModelEmissoras obj)
        {
            Emissora newEmissora = new Emissora()
            {
                id = obj.IdEmissoras.ToString(),
                NomeFantasia = obj.NomeFantasia,
                RazaoSocial = obj.RazaoSocial,
                tipo = obj.Tipo,
            };

            _db.Emissoras.Add(newEmissora);
            _db.SaveChanges();
        }


        public List<ModelEmissoras> CarregarEmissoras()
        {
            List<Emissora> loademissoras = _db.Emissoras.ToList();

            List<ModelEmissoras> emissorasCarregadas = loademissoras.Select(emissora => new ModelEmissoras
            {
                IdEmissoras = Guid.Parse(emissora.id),
                NomeFantasia = emissora.NomeFantasia,
                RazaoSocial = emissora.RazaoSocial,
                Tipo = emissora.tipo
            }).ToList();

            return emissorasCarregadas;
        }
        public void alterarEmissoras(ModelEmissoras obj)
        {
            var emissoraExistente = _db.Emissoras.Find(obj.IdEmissoras.ToString());

            if (emissoraExistente != null)
            {
                emissoraExistente.NomeFantasia = obj.NomeFantasia;
                emissoraExistente.RazaoSocial = obj.RazaoSocial;
                emissoraExistente.tipo = obj.Tipo;

                _db.SaveChanges();
            }
        }
        public void ExcluirEmissoras(string id)
        {
            var emissoraDelete = _db.Emissoras.Where(e => e.id == id).Single();
            _db.Emissoras.Remove(emissoraDelete);
            _db.SaveChanges();
        }
    }
}
