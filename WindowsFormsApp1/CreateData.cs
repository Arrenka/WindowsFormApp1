using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using ApplicationContext = WindowsFormsApp1.Model.ApplicationContext;

namespace WindowsFormsApp1
{
    public static class CreateData
    {
        public static void Create()
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                OrgUnit aof = new OrgUnit { Name = "Алматинский Областной Филиал" };
                OrgUnit tf = new OrgUnit { Name = "Талдыкорганский Филиал" };
                OrgUnit pf = new OrgUnit { Name = "Павлодарский Филиал" };

                db.OrgUnits.AddRange(aof, tf, pf);
                db.SaveChanges();

                OrgUnit hr = new OrgUnit { Name = "Отдел кадров", BusinessUnitId = aof.Id };
                OrgUnit hr2 = new OrgUnit { Name = "Отдел кадров", BusinessUnitId = tf.Id };
                OrgUnit acc = new OrgUnit { Name = "Бухгалтерия", BusinessUnitId = pf.Id };
                OrgUnit isd = new OrgUnit { Name = "Отдел инф.безопастность", BusinessUnitId = pf.Id };

                db.OrgUnits.AddRange(hr, hr2, acc, isd);
                db.SaveChanges();

                OrgUnit ivanovII = new OrgUnit { Name = "Иванов И.И.", DepartmentId = hr.Id };
                OrgUnit carelinAE = new OrgUnit { Name = "Карелин А.Е.", DepartmentId = hr.Id };
                OrgUnit iscacovDE = new OrgUnit { Name = "Искаков Д.Е.", DepartmentId = isd.Id };
                OrgUnit mucashevaDR = new OrgUnit { Name = "Мукашева Д.Р.", DepartmentId = acc.Id };
                OrgUnit bukezhanovAK = new OrgUnit { Name = "Букежанов А.К.", DepartmentId = isd.Id };
                OrgUnit yemST = new OrgUnit { Name = "Ем С.Т.", DepartmentId = isd.Id };
                OrgUnit konevVA = new OrgUnit { Name = "Конев В.А.", DepartmentId = acc.Id };
                OrgUnit eshenculovSE = new OrgUnit { Name = "Есенкулов С.Е.", DepartmentId = acc.Id };
                OrgUnit tarasovAS = new OrgUnit { Name = "Тарасов А.С.", DepartmentId = hr2.Id };
                OrgUnit bulbaTS = new OrgUnit { Name = "Бульба Т.С.", DepartmentId = hr.Id };
                OrgUnit petrovGB = new OrgUnit { Name = "Петров Г.Б.", DepartmentId = hr2.Id };
                OrgUnit zaicevMV = new OrgUnit { Name = "Зайцев М.В.", DepartmentId = hr.Id };

                db.OrgUnits.AddRange(ivanovII, carelinAE, iscacovDE, mucashevaDR, bukezhanovAK, yemST, konevVA, eshenculovSE, tarasovAS, bulbaTS, petrovGB, zaicevMV);
                db.SaveChanges();

                Furniture stul = new Furniture { Name = "Стул" };
                Furniture divan = new Furniture { Name = "Диван" };
                Furniture stol = new Furniture { Name = "Стол" };
                Furniture shkaf = new Furniture { Name = "Шкаф" };
                Furniture lamp = new Furniture { Name = "Лампа" };
                Furniture stol2 = new Furniture { Name = "Стол2" };
                Furniture creslo = new Furniture { Name = "Кресло" };
                Furniture tumba = new Furniture { Name = "Тумбочка" };
                Furniture camod = new Furniture { Name = "Камод" };
                Furniture polca = new Furniture { Name = "Полка" };
                Furniture tabu = new Furniture { Name = "Табуретка" };
                Furniture stolic = new Furniture { Name = "Журнальный столик" };

                db.Furnituries.AddRange(stul, divan, stol, shkaf, lamp, stol2, creslo, tumba, camod, polca, tabu, stolic);
                db.SaveChanges();

                ivanovII.Furnitures.Add(stul);
                carelinAE.Furnitures.Add(divan);
                iscacovDE.Furnitures.Add(stol);
                mucashevaDR.Furnitures.Add(shkaf);
                bukezhanovAK.Furnitures.Add(lamp);
                yemST.Furnitures.Add(stol2);
                konevVA.Furnitures.Add(creslo);
                eshenculovSE.Furnitures.Add(tumba);
                tarasovAS.Furnitures.Add(camod);
                bulbaTS.Furnitures.Add(polca);
                petrovGB.Furnitures.Add(tabu);
                zaicevMV.Furnitures.Add(stolic);


                db.SaveChanges();

            }
        }
    }
}
