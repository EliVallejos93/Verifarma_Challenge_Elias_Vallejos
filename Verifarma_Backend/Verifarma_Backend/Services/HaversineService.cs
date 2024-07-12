using System;

namespace Verifarma_Challenge_Backend.Services
{
    //la fórmula del Haversine calcula la distancia entre dos puntos en la superficie de una esfera (aproximadamente la Tierra).
    public static class HaversineService
    {
        public static double Distancia(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Radio de la Tierra en km
            var lat = ToRadians(lat2 - lat1);
            var lon = ToRadians(lon2 - lon1);
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                     Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                     Math.Sin(lon / 2) * Math.Sin(lon / 2);
            var h2 = 2 * Math.Atan2(Math.Sqrt(h1), Math.Sqrt(1 - h1));
            return R * h2;
        }

        private static double ToRadians(double angle) => angle * Math.PI / 180;
    }
}
