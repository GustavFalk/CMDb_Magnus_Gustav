using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CMDb_MGM.Data;
using CMDb_MGM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMDb_MGM.Controllers
{
    
    public class StartController : Controller
    {
        private IOMDbRepo omdbrepo;
        private ICMDbRepo cmdbrepo;

        public StartController(IOMDbRepo omdbrepo, ICMDbRepo cmdbrepo)
        {
            this.omdbrepo = omdbrepo;
            this.cmdbrepo = cmdbrepo;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {try
            { 
            var CMDbToplist = await cmdbrepo.GetTopmoviesMovieCMDb("toplist?type=rating&count=5");
            IndexViewModel viewModel = new IndexViewModel(await omdbrepo.GetMovieListOMDB(CMDbToplist),CMDbToplist);
            return View(viewModel);
            }
            //Ifall något går fel så skickas användaren till Error vyn.
            catch (Exception) {
                return RedirectToAction("Index", "Error");
            }
        }


       

    }
}