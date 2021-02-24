using System;
using back.Models;
using back.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace back.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private const int Value = 1;
        CheckService _checkService = new CheckService();
        public PremiumController()
        {
        }

        [HttpGet]
        public ActionResult Get()
        {
           return Ok(this._checkService.GetChecks());
        }


        [HttpPost]
        // public ActionResult Post()
        public ActionResult Post(Premium premium)
        {
            Console.WriteLine("paso");
            List<Check> checkers = this._checkService.GetChecks();
            double result =0;
            Console.WriteLine(premium.DateOfBirth);
            Console.WriteLine(premium.Age);
            Console.WriteLine(premium.State);
            
            foreach (Check check in checkers)
            {
                if (check.checker(premium)==true){
                    result = check.Premium;
                    break;
                } 
                Console.WriteLine("");
            }
            if(result==0)
            {
                result=_checkService.getDefault().Premium;
            }
            return Ok(new Response(result));
        }
    }
}
