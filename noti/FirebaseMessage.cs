using FirebaseAdmin.Messaging;

namespace noti
{
    internal class FirebaseMessage
    {
        public FirebaseMessage()
        {
        }

        public string Token { get; set; }
        public Notification Notification { get; set; }
    }
}