 /// <summary>
        /// $WarpPoints Command
        /// </summary>
        /// <param name="warpPointsPacket"></param>
        public void WarpPoints(WarpPointsPacket warpPointsPacket)
        {
            Session.SendPacket(Session.Character.GenerateSay("-------", 10));
            IEnumerable<WarpPointDTO> warppoints = DAOFactory.WarpPointDAO.LoadAll();
            foreach (WarpPointDTO x in warppoints)
            {
                Session.SendPacket(Session.Character.GenerateSay(string.Format("{0} ({1})", x.Name, DAOFactory.MapDAO.LoadById(x.MapId).Name), (x.Authority > Session.Account.Authority) ? 11 : 12));
            }
            Session.SendPacket(Session.Character.GenerateSay("-------", 10));
        }

		/// <summary>
        /// $Warp Command
        /// </summary>
        /// <param name="warpPacket"></param>
        public void Warp(WarpPacket warpPacket)
        {
            ClientSession client = null;

            if (warpPacket.WarpPoint == null || warpPacket.WarpPoint.Length < 1)
            {
               return;
            }
            if (Session.Character.IsChangingMapInstance || Session.Character.MapInstance.IsScriptedInstance || Session.Character.InExchangeOrTrade || Session.Character.HasShopOpened || Session.Character.IsSeal || Session.CurrentMapInstance.MapInstanceType.Equals(MapInstanceType.TalentArenaMapInstance) || Session.CurrentMapInstance.MapInstanceType.Equals(MapInstanceType.IceBreakerInstance))
            {
                Session.SendPacket(Session.Character.GenerateSay("There is a better time for that", 11));
            }

            WarpPointDTO warpPoint = DAOFactory.WarpPointDAO.LoadFromName(warpPacket.WarpPoint).FirstOrDefault();
            if (warpPoint == null)
            {
                Session.SendPacket(Session.Character.GenerateSay("Your requested WarpPoint doesn't exist", 11));
				return;
            }
            
			if (warpPoint.Authority > Session.Account.Authority)
            {
                Session.SendPacket(Session.Character.GenerateSay(string.Format("You need the Authority of {0}", Enum.GetName(typeof(AuthorityType), warpPoint.Authority)), 11));
                return;
            }
         
            ServerManager.Instance.ChangeMap(Session.Character.CharacterId, warpPoint.MapId, warpPoint.MapX, warpPoint.MapY);
            Session.SendPacket(Session.Character.GenerateSay("Warp complete", 12));
        }

