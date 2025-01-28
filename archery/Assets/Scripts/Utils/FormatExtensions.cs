namespace Archery.Utils
{
    public static class FormatExtensions
    {
        public static char ToShort(this bool self) => self ? '+' : '-';
    }
}