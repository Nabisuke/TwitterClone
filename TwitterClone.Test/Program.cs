using TwitterClone.Domain.Entities;

var notifications = new List<Notification>
{
    new LikeNotification(Guid.NewGuid(), Guid.NewGuid()),
    new CommentNotification(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()),
    new FriendRequestNotification(Guid.NewGuid(), Guid.NewGuid()),
    new MentionNotification(Guid.NewGuid(), Guid.NewGuid()),
    new SystemNotification("System maintenance scheduled for tonight at 11 PM.")
};

foreach(var notification in notifications)
{
    Console.WriteLine(notification.GetMessage());
}