using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTful_AngularJs.Models;

namespace RESTful_AngularJs.Controllers
{
    public class QLSinhVienApiController : ApiController
    {
        [HttpGet]
        [Route("api/student/all")]
        public IHttpActionResult GetAll()
        {
            using (QLSVEntities db = new QLSVEntities())
            {
                var list = db.SINHVIENs.ToList();
                return Ok(list);
            }
        }

        [HttpPost]
        [Route("api/student/search")]
        public IHttpActionResult Search([FromBody]string mssv)
        {
            using (QLSVEntities db = new QLSVEntities())
            {
                SINHVIEN sv = (from s in db.SINHVIENs where s.MSSV == mssv select s).First();
                return Ok(sv);
            }
        }

        [HttpPost]
        [Route("api/student/Add")]
        public IHttpActionResult Add ([FromBody]SINHVIEN st)
        {
            using (QLSVEntities db = new QLSVEntities())
            {
                db.SINHVIENs.Add(st);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpPost]
        [Route("api/student/Delete")]
        public IHttpActionResult Delete([FromBody]string mssv)
        {
            using (QLSVEntities db = new QLSVEntities())
            {
                SINHVIEN sv = (from s in db.SINHVIENs where s.MSSV == mssv select s).First();
                db.SINHVIENs.Remove(sv);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpPost]
        [Route("api/student/Update")]
        public IHttpActionResult Update([FromBody]SINHVIEN news_sv)
        {
            using (QLSVEntities db = new QLSVEntities())
            {
                SINHVIEN sv = (from s in db.SINHVIENs where s.MSSV == news_sv.MSSV select s).First();
                sv.HOTEN = news_sv.HOTEN;
                sv.KHOA = news_sv.KHOA;
                sv.NGANH = news_sv.NGANH;
                sv.DIACHI = news_sv.DIACHI;
                sv.SDT = news_sv.SDT;

                db.SaveChanges();
                return Ok();
            }
        }
    }
}
