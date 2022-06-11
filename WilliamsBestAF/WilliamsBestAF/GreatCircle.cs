using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using static System.Math;

namespace WilliamsBestAF
{
    public class GreatCircle
    { 
        public double ClairautsFormula(double lat1Radians, double lng1Radians, double lat2Radians, double lng2Radians)
        {
            double tc = 0;
            double lat = 0;
            double tc1 = 0;
            double tc2 = 0;
            double latmx = Math.Acos(Math.Abs(Math.Sin(tc) * Math.Cos(lat)));
            bool EqualParts = Math.Sin(tc1) * Math.Cos(lat1Radians) == Math.Sin(tc2) * Math.Cos(lat2Radians);

            string result = latmx.ToString() + " " + EqualParts.ToString();
            return 25.0;
        }

        public double CrossingParallels(double lat1Radians, double lng1Radians, double lat2Radians, double lng2Radians, double lat3Radians, double lng3Radians)
        {
            string stringResult = "";
            double dlon = 0;
            double lon3_1 = 0;
            double lon3_2 = 0;
            double distance = GreatCircle_Calculation(lat1Radians, lng1Radians, lat2Radians, lng2Radians);

            double l12 = lng1Radians - lng2Radians;
            double A = Math.Sin(lat1Radians) * Math.Cos(lat2Radians) * Math.Cos(lat3Radians) * Math.Sin(l12);
            double B = Math.Sin(lat1Radians) * Math.Cos(lat2Radians) * Math.Cos(lat3Radians) * Math.Cos(l12) - Math.Cos(lat1Radians) * Math.Sin(lat2Radians) * Math.Cos(lat3Radians);
            double C = Math.Cos(lat1Radians) * Math.Cos(lat2Radians) * Math.Sin(lat3Radians) * Math.Sin(l12);
            double lon = Math.Atan2(B, A);      // (atan2(y, x) convention)
            if (Math.Abs(C) > Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2)))
            {
                stringResult = "no crossing";
            }

            else
            {
                dlon = Math.Acos(C / Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2)));
                lon3_1 = (lng1Radians + dlon + lon + Math.PI % 2 * Math.PI) - Math.PI;
                lon3_2 = (lng1Radians - dlon + lon + Math.PI % 2 * Math.PI) - Math.PI;
            }

            string strResult = !String.IsNullOrEmpty(stringResult) ? stringResult : string.Empty;
            return 15.0;

                       
        }

        public double CrossTrackError(double lat1Radians,double lng1Radians,double lat2Radians,double lng2Radians, double lat3Radians, double lng3Radians)
        {
            double XTD = 0;
            // string[] dist_ADString = await gc.Get_Cooridates(this, null);

            //string thisLatString = dist_ADString[0];
            //string thisLngString = dist_ADString[1];

            //double thisLat = double.Parse(thisLatString);
            //double thisLng = double.Parse(thisLngString);

            double dist_AD = GreatCircle_Calculation(lat1Radians, lng1Radians, lat3Radians, lng3Radians);
            double dist_AB = GreatCircle_Calculation(lat1Radians, lng1Radians, lat2Radians, lng2Radians);
            double crs_AD = CourseBetweenPoints(dist_AD, lat1Radians, lng1Radians, lat3Radians, lng3Radians);
            double crs_AB = CourseBetweenPoints(dist_AB, lat1Radians, lng1Radians, lat2Radians, lng2Radians);


            XTD = Math.Asin(Math.Sin(dist_AD) * Math.Sin(crs_AD - crs_AB));
            // positive XTD means right of course, negative means left
            // If the point A is the N. or S. Pole replace crs_AD-crs_AB with lon_D-lon_B or lon_B-lon_D respectively

            // The "along track distance", ATD, the distance from A along the course towards B to the point abeam D is given by:
            double ATD = Math.Acos(Math.Cos(dist_AD) / Math.Cos(XTD));

            // For very short distances:
            double ATD2 = Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(Math.Pow(dist_AD, 2)), 2) - Math.Pow(Math.Sin(XTD), 2) / Math.Cos(XTD)));
            string directionFromCourse = "";
            if (ATD > 0)
            {
                directionFromCourse = "Nautical Miles right of course";
            }
            else if (ATD < 0)
            {
                directionFromCourse = "Nautical Miles left of course";
            }
            else
            {
                directionFromCourse = "On Course";
            }

            double NauticalMileResult = RadiansToNauticalMiles(XTD);
            double AlongTrackDistance = RadiansToNauticalMiles(ATD);
            string results = AlongTrackDistance.ToString() + " " + "Nautical Miles Along course";
            string results2 = NauticalMileResult.ToString() + " " + directionFromCourse;
            return 15.0;
        }
        public double[] IntermediatePointsOnAGreatCircle(double f,double lat1Radians,double lng1Radians, double lat2Radians,double lng2Radians)
        {     
            double d = GreatCircle_Calculation(lat1Radians, lng1Radians, lat2Radians, lng2Radians);

            double A = Math.Sin((1 - f) * d) / Math.Sin(d);
            double B = Math.Sin(f * d) / Math.Sin(d);
            double x = A * Math.Cos(lat1Radians) * Math.Cos(lng1Radians) + B * Math.Cos(lat2Radians) * Math.Cos(lng2Radians);
            double y = A * Math.Cos(lat1Radians) * Math.Sin(lng1Radians) + B * Math.Cos(lat2Radians) * Math.Sin(lng2Radians);
            double z = A * Math.Sin(lat1Radians) + B * Math.Sin(lat2Radians);
            double lat = Math.Atan2(z, Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
            double lon = Math.Atan2(y, x);
            double latDD = RadiansToDegrees(lat);
            double lonDD = RadiansToDegrees(lon);
            // string latDMS = Deg_DMS(latDD);
            // string lonDMS = Deg_DMS(lonDD);

            // string results = latDMS + " " + "Latitude" + " " + lonDMS + " " + "Longitude";
            return new double[] { latDD, lonDD };
        }

        public double IntersectingRadials(double lat1Radians, double lng1Radians, double lat2Radians, double lng2Radians)
        {
            double lat3;
            double l12;
            double A;
            double B;
            double C;
            double lon;
            double dlon;
            double lon3_1;
            double lon3_2;

            double distance = GreatCircle_Calculation(lat1Radians, lng1Radians, lat2Radians, lng2Radians);

            lat3 = 36 * PI / 180;
            l12 = lng1Radians - lng2Radians;
            A = Sin(lat1Radians) * Cos(lat2Radians) * Cos(lat3) * Sin(l12);
            B = Sin(lat1Radians) * Cos(lat2Radians) * Cos(lat3) * Cos(l12) - Cos(lat1Radians) * Sin(lat2Radians) * Cos(lat3);
            C = Cos(lat1Radians) * Cos(lat2Radians) * Sin(lat3) * Sin(l12);
            lon = Atan2(B, A);

            var answer = Abs(C) > Sqrt(Pow(A, 2) + Pow(B, 2)) ? Abs(C) : Sqrt(Pow(A, 2) + Pow(B, 2));
            dlon = Acos(C / Sqrt(Pow(A, 2) + Pow(B, 2)));
            lon3_1 = (lng1Radians + dlon + lon + PI % 2 * PI) - PI;
            lon3_2 = (lng1Radians - dlon + lon + PI % 2 * PI) - PI;
            // lon3_1 lies between lon1 and lon2, but lon3_2 does not, so the 36 degree parallel is crossed once between LAX and JFK at lon3_1

            double answerInDegrees = RadiansToDegrees(lon3_1);

            string results = answerInDegrees.ToString() + " " + "degrees longitude";
            return 15.0;
        }

        public double LatitudeLongitudeGivenRadialAndDistance(double distance,double course, double lat1Radians, double lng1Radians, double lat2Radians, double lng2Radians)
        {
            double distanceMiles = MilesToNauticalMiles(distance);
            double distancetxt = NauticalMilesToRadians(distanceMiles);
            double truecourse = Deg_Radians(course);
            double lat;
            double lng;
            double dlon;

            // distances 1/4 around globe

            lat = Math.Asin(Math.Sin(lat1Radians) * Math.Cos(distance) + Math.Cos(lat1Radians) * Math.Sin(distance) * Math.Cos(truecourse));

            if (Math.Cos(lat) == 0)
                lng = lng1Radians;
            else
                lng = (lng1Radians - Math.Asin(Math.Sin(truecourse) * Math.Sin(distance) / Math.Cos(lat)) + Math.PI % (2 * Math.PI)) - Math.PI;

            // distances greater use this
            double lat2 = Math.Asin(Math.Sin(lat1Radians) * Math.Cos(distance) + Math.Cos(lat1Radians) * Math.Sin(distance) * Math.Cos(truecourse));
            dlon = Math.Atan2(Math.Sin(truecourse) * Math.Sin(distance) * Math.Cos(lat1Radians), Math.Cos(distance) - Math.Sin(lat1Radians) * Math.Sin(lat));
            double lng2 = (lng1Radians - dlon + Math.PI % 2 * Math.PI) - Math.PI;
            double latAnswerDeg = RadiansToDegrees(lat);
            double lngAnswerDeg = RadiansToDegrees(lng);

            string latitudeDeg = Deg_DMS(latAnswerDeg);
            string longitudeDeg = Deg_DMS(lngAnswerDeg);
            string results = latitudeDeg + " " + "Latitude";
            string results2 = longitudeDeg + " " + "Longitude";
            return 15.0;
        }

        public double LatitudeOfPointOnGC(double lngDeg3,double lngMin3, double lat1Radians, double lng1Radians, double lat2Radians, double lng2Radians,double lat3Radians,double lng3Radians)
        {
            double lat = 0;

            if (Math.Sin(lng1Radians - lng2Radians) != 0)
            {
                lat = Math.Atan((Math.Sin(lat1Radians) * Math.Cos(lat2Radians) * Math.Sin(lng3Radians - lng2Radians) - Math.Sin(lat2Radians) * Math.Cos(lat1Radians) * Math.Sin(lng3Radians - lng1Radians)) / (Math.Cos(lat1Radians) * Math.Cos(lat2Radians) * Math.Sin(lng1Radians - lng2Radians)));
            }
            else
                lat = 0;

            double resultInDegrees = RadiansToDegrees(lat);
            string resultDegreesMin = Deg_DMS(resultInDegrees);

            string results = resultDegreesMin.ToString() + " " + "Latitude";    
            string results2 = lngDeg3.ToString() + " " + lngMin3.ToString() + " 0" + " Longitude";
            return 15.0;
        }

        public double DMS_Degrees(double deg, double min, double sec)
        {
            double answer = deg + (min / 60) + (sec / 3600);
            if (deg < 0)
                answer -= 1;
            return answer;
        }
        public double Deg_Radians(double deg)
        {
            double Deg = deg * Math.Sign(deg);
            double answer = (Math.PI / 180) * Deg;
            double Negation = Math.Sign(deg);
            return (answer * Negation);
        }
        public double Radians_Deg(double rad)
        {
            double Rad = rad * Math.Sign(rad);
            double answer = (180 / Math.PI) * Rad;
            double Negation = Math.Sign(rad);
            return (answer * Negation);
        }
        public string  Deg_DMS(double deg)
        {
            double Negation = Math.Sign(deg);
            double Deg = deg * Negation;
            double DecimalPart = (Deg - Math.Truncate(Deg));
            double IntegerPart = Math.Truncate(Deg);
            double Min = DecimalPart * 60;
            double MinDecimalPart = Min - Math.Truncate(Min);
            double MinIntegerPart = Math.Truncate(Min);
            double Sec = Math.Round(MinDecimalPart * 60, 0);
            double IntegerWithSign = Negation * IntegerPart;
            string result = $"{IntegerWithSign} {MinIntegerPart} {Sec}";
            return result;
        }
        public double GreatCircle_Calculation(double lat1, double long1, double lat2, double long2)
        {
            double result = Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(long1 - long2);
            double resultAnswer = Math.Acos(result);

            double precisionAnswer = 2 * Math.Asin(Math.Sqrt((Math.Pow(Math.Sin((lat1 - lat2) / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) *(Math.Sin(Math.Pow((long1 - long2) / 2, 2))))));


            return resultAnswer;
        }
        public string ViewableMileage_AtHeight(double heightFeet)
        {
            Console.WriteLine("Height above earth in feet");

            //double height = double.Parse(Console.ReadLine());
            double heightMiles = 0;
            heightMiles = (heightFeet / 5280) + 3959;
            double angleDegrees = (Math.Asin((3959 / heightMiles)) * (180 / Math.PI));
            angleDegrees = Math.Round(angleDegrees * 2, 1);
            double answer = Math.Round(180 - angleDegrees, 1);
            double visible = Math.PI * 2 * answer;
            //Console.WriteLine($"Viewing {answer} degrees of 360 in two directions");
            double EarthCircumference = Math.PI * 3959 * 2;
            double arch = answer / 360;
            answer = arch * EarthCircumference;
            answer = Math.Round(answer / 2, 0);
            // Console.WriteLine($"visible part {answer} miles in one direction.");
            //Console.ReadKey();
            return answer.ToString();

        }
        public double[] Get_AntiPodal(double latdeg, double latmin, double latsec, double longdeg, double longmin, double longsec)
        {
            double Lat = DMS_Degrees(latdeg, latmin, latsec);
            double Long = DMS_Degrees(longdeg, longmin, longsec);
            Lat = -Lat;
            if (Long > 0 && Long < 360)
                Long = Long - 180;
            else
            Long = Long + 180;
            return new double[] { Lat, Long };
        }

        public double GetDistantThroughEarth(double lat1Radians, double lng1Radians, double lat2Radians, double lng2Radians)
        {
            double X = Math.Cos(lat1Radians) * Math.Cos(lng1Radians);
            double Y = Math.Cos(lat1Radians) * Math.Sin(lng1Radians);
            double Z = Math.Sin(lat1Radians);

            double X2 = Math.Cos(lat2Radians) * Math.Cos(lng2Radians);
            double Y2 = Math.Cos(lat2Radians) * Math.Sin(lng2Radians);
            double Z2 = Math.Sin(lat2Radians);

            double result = Math.Sqrt(Math.Pow((X2 - X), 2) + Math.Pow((Y2 - Y), 2) + Math.Pow((Z2 - Z), 2));
            result = result * 3959;
            return result;
        }

        public double RadiansToDegrees(double radians)
        {
            return (180 / Math.PI) * radians;
        }

        public double DegreesToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        public double CourseBetweenPoints(double distance, double lat1Radians, double lng1Radians, double lat2Radians, double lng2Radians)
        {
            double tc1 = 0;
                     

            if (Math.Cos(lat1Radians) < 0.00010)
                if (lat1Radians > 0)
                    tc1 = Math.PI;
                else
                    tc1 = 2 * Math.PI;
            else if (Math.Sin(lng2Radians - lng1Radians) < 0)
            {
                tc1 = Math.Acos((Math.Sin(lat2Radians) - Math.Sin(lat1Radians) * Math.Cos(distance)) / (Math.Sin(distance) * Math.Cos(lat1Radians)));
            }
            else
                tc1 = 2 * Math.PI - Math.Acos((Math.Sin(lat2Radians) - Math.Sin(lat1Radians) * Math.Cos(distance)) / (Math.Sin(distance) * Math.Cos(lat1Radians)));
            // double CourseDegrees = Math.Round(RadiansToDegrees(tc1), 0);

            return tc1;
        }

        public async System.Threading.Tasks.Task<string[]> Get_Cooridates(object sender, EventArgs e)
        {
            var coor = await Geolocation.GetLocationAsync(new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Medium,
                Timeout = TimeSpan.FromSeconds(30)
            });
            var cooridates = new string[] { coor.Latitude.ToString(), coor.Longitude.ToString() };
            return cooridates;
        }

        public double NauticalMilesToRadians(double nauticalmiles)
        {
            double distanceradians = (Math.PI / (180 * 60)) * nauticalmiles;
            return distanceradians;
        }

        public double RadiansToNauticalMiles(double radians)
        {
            double nauticalmiles = ((180 * 60) / Math.PI) * radians;
            return nauticalmiles;
        }

        public double NauticalMilesToMiles(double nauticalmiles)
        {
            return 1.1507794 * nauticalmiles;
        }

        public double MilesToNauticalMiles(double miles)
        {
            return miles / 1.1507794;
        }

    }
}
