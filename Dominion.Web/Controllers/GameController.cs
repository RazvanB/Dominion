﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Dominion.GameHost;
using Dominion.Rules;
using Dominion.Rules.CardTypes;
using Dominion.Web.ActionFilters;
using Dominion.Web.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Dominion.Web.Controllers
{
    [InjectGame]
    public class GameController : Controller
    {
        public IGameHost Host { get; set;}
        public IGameClient Client { get; set; }

        public ActionResult Index()
        {
            return RedirectToAction("Play");
        }

        [HttpGet]
        public ActionResult Play()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GameData(string playerId)
        {
            var model = Host.GetGameState(Client);
            return JsonNet(model);
        }

        [HttpPost]
        public ActionResult PlayCard(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult BuyCard(Guid id)
        {
            var model = new PlayerActionResultViewModel();
            Host.AcceptMessage(new BuyCardMessage {PileId = id});
            return Json(model);
        }

        [HttpPost]
        public ActionResult DoBuys()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult EndTurn()
        {
            throw new NotImplementedException();
        }



        private ActionResult JsonNet(GameViewModel model)
        {
            return new JsonNetResult
            {
                Data = model,
                SerializerSettings = new JsonSerializerSettings { Converters = { new GameViewModelConverter(this.Url) } }
            };
        }

        

        
    }
    
    public class GameViewModelConverter : KeyValuePairConverter
    {
        private readonly UrlHelper _url;

        public GameViewModelConverter(UrlHelper url)
        {
            _url = url;
        }

        public override bool CanConvert(Type objectType)
        {
            return
                new[]
                    {
                        typeof (CardViewModel), 
                        typeof (CardPileViewModel), 
                        typeof (DeckViewModel),
                        typeof (DiscardPileViewModel)
                    }
                .Contains(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string cardName = string.Empty;

            if (value is CardViewModel)
                cardName = ((CardViewModel)value).Name;
            else if (value is CardPileViewModel)
                cardName = ((CardPileViewModel)value).Name;
            else if (value is DeckViewModel)
                cardName = ((DeckViewModel)value).IsEmpty ? "empty" : "deck";
            else if (value is DiscardPileViewModel)
                cardName = ((DiscardPileViewModel)value).IsEmpty ? "empty" : ((DiscardPileViewModel)value).TopCardName;

            JObject o = JObject.FromObject(value);
            o["ImageUrl"] = _url.Content(string.Format("~/Content/Images/Cards/{0}.jpg", cardName));
            writer.WriteRawValue(o.ToString());
        }
    }
}
