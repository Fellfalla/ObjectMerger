using System;

namespace Tapako.ObjectMerger
{
    public interface IObjectMergerLogger
    {
        void Debug       (string message, params object[] paramList);
        void Warning     (string message, params object[] paramList);
        void Error       (string message, params object[] paramList);
        void Info        (string message, params object[] paramList);

        void Debug       (Exception exception);
        void Warning     (Exception exception);
        void Error       (Exception exception);
        void Info        (Exception exception);
    }
}