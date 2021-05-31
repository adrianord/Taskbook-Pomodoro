using System;
using TaskBookPomo.Common.Constants;

namespace TaskBookPomo.Common.Helpers
{
    public record AboutInfo(string Application, DateTime UpSince, string UpFor, string? ReleaseCommit = null, string? ReleaseTag = null);

    public interface IAboutInfoHelper
    {
        AboutInfo GetAboutInfo();
    }

    public class AboutInfoHelper : IAboutInfoHelper
    {
        private readonly DateTime _startDateTimeUtc;

        public AboutInfoHelper()
        {
            _startDateTimeUtc = DateTime.UtcNow;
        }

        public AboutInfo GetAboutInfo() => new
        (
            Application: ApplicationInfo.FullName,
            UpSince: _startDateTimeUtc,
            UpFor: GetUpForDetails()
        );

        private string GetUpForDetails()
        {
            var upSpan = DateTime.UtcNow - _startDateTimeUtc;
            return $"{upSpan.Days} days, {upSpan.Hours} Hours, {upSpan.Minutes} minutes, {upSpan.Seconds} seconds, {upSpan.Milliseconds} milliseconds";
        }
    }
}