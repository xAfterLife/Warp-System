        private static IWarpPointDAO _warpPointDAO;

        public static IWarpPointDAO WarpPointDAO => _warpPointDAO ?? (_warpPointDAO = new WarpPointDAO());