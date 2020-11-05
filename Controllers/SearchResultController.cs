using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMDb_MGM.Data;
using CMDb_MGM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMDb_MGM.Controllers
{

    public class SearchResultController : Controller
    {
        private IOMDbRepo omdbrepo;

        public SearchResultController(IOMDbRepo omdbrepo)
        {
            this.omdbrepo = omdbrepo;
        }
        
        [Route("/search-result")]
        public async Task<IActionResult> Index(string search)
        {
            try
            {
                SearchResultViewModel viewModel = new SearchResultViewModel(await omdbrepo.GetMovieListOMDB(await omdbrepo.GetSearchResultsOMDB(search)));
                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
    
}