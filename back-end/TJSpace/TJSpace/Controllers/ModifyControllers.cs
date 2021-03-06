﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TJSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModifyController : ControllerBase
    {
        private readonly DataDBContext dbContext;

        public ModifyController(DataDBContext context)
        {
            dbContext = context;
        }

        //修改个人信息
        //PUT
        [HttpPut]
        [Route("Info")]
        public ActionResult<string> ModifyInfo(string id, string nickname, int gender, string phoneNumber, string majorID, int year, int degree)
        {
            var info = dbContext.Users.Where(n => n.UserId.Equals(id)).ToList().FirstOrDefault();
            info.NickName = nickname;
            info.Gender = gender;
            info.PhoneNumber = phoneNumber;
            info.MajorId = majorID;
            dbContext.SaveChanges();
            return Ok(new
            {
                status = true,
                msg = "修改信息成功"
            });

        }
    }
}