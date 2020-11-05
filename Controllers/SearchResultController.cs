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
                //Vymodellens värde kommer från en söksträng som matas in i OMDb, som sedan spottar ut en lista med filmer som matchar sökordet.
                //Listan som kommer ut är informationsmässigt relativt bristfällig.
                //För att få mer information kring filmerna i söklistan kör vi den genom OMDB ytterligare en gång, med en sökning per film.
                // Den listan används i vymodellen för att presentera all den information som vi önskar presentera.
                SearchResultViewModel viewModel = new SearchResultViewModel(await omdbrepo.GetMovieListOMDB(await omdbrepo.GetSearchResultsOMDB(search)));
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