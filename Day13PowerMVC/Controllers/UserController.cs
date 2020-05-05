using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Model;

namespace Day13PowerMVC.Controllers
{
    public class UserController : Controller
    {
        UserDAL dal = new UserDAL();

        // GET: User
        public ActionResult Show()
        {
            return View();
        }

        public ActionResult UserRoleList()
        {
            var list = dal.ShowUserRole();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RoleList()
        {
            var list = dal.GetRoleInfos();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PowerList(int uId=0)
        {
            var list = dal.GetUserRolesById(uId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 分配角色权限
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddUserRole(UserRole mod)
        {
            return dal.AddUserRole(mod);
        }

        /// <summary>
        /// 取消角色权限
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="rId"></param>
        /// <returns></returns>
        [HttpPost]
        public int DelUserRole(int uId, int rId)
        {
            return dal.DelUserRole(uId, rId);
        }
    }
}