using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoObektaAdmin.Models
{
    public class TouristsModel
    {
        public List<TouristModel> TouristInfo { get; set; }

        public TouristsModel()
        {
            this.TouristInfo = new List<TouristModel>();
        }

        public void loadTourists()
        {
            using (var db = new SitesDB.SitesDBEntities())
            {
                var tourists = (from t in db.Tourists select t);
                foreach (var tourist in tourists)
                {
                    TouristModel user = new TouristModel();
                    user.AndroidID = tourist.AndroidID;
                    user.MessageToUser = tourist.MessageToUser;
                    user.VisitedSites = tourist.VisitedSites;
                    this.TouristInfo.Add(user);
                }
                TouristInfo.OrderByDescending(x => x.VisitedSites);
            }
        }

        public void sendMessageToUser(string androidID, string message)
        {
            using (var db = new SitesDB.SitesDBEntities())
            {
                var specificUser = (from t in db.Tourists where t.AndroidID == androidID select t).FirstOrDefault();
                if (specificUser != null)
                {
                    specificUser.MessageToUser = message;
                    db.SaveChanges();
                }
            }
        
        }
    }
}