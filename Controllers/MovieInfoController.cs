using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMDb_MGM.Data;
using CMDb_MGM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMDb_MGM.Controllers
{
    public class MovieInfoController : Controller
    {
        private IOMDbRepo omdbrepo;
        private ICMDbRepo cmdbrepo;

        public MovieInfoController(IOMDbRepo omdbrepo, ICMDbRepo cmdbrepo)
        {
            this.omdbrepo = omdbrepo;
            this.cmdbrepo = cmdbrepo;
        }

        [Route ("/movie")]
        public async Task<IActionResult> Index(string id)
        {
            try
            {
                MovieInfoViewModel viewModel = new MovieInfoViewModel(await cmdbrepo.GetMovieCMDb(id), await omdbrepo.GetMovieByID(id));
                return View(viewModel);
            }
            //Ifall något går fel så skickas användaren till Error vyn.
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
 }
