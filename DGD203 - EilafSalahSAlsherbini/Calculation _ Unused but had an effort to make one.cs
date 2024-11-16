namespace FirstGame
{
    public static class Calculator //I was struggling to use my calculator very well into my program.
    {
        private const float Distance = 150f; //the distnace from start to finish. (before and in the tunnel)
        public const float Tunnel_roof_threshold = 25f; //the actual average for a tunnel is 23 meters, but 25 for simility.
        
        
        public static float Time(float Speed)
        {
            return (Distance / Speed);
        }

        public static float RoofCompare(float Vehicle_Height) //supposed to use as comparrision for the threshold of the roof and vehicle and then use a comparision with >= and <=.
        {
            return Tunnel_roof_threshold - Vehicle_Height;
        }
    }
}