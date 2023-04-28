namespace HR.LeaveManagement.UnitTests.Mocks;

public class MockRepositories
{

    public static Mock <ILeaveTypeRepositories> GetLeaveTypeRepository()
    {
        var leaveTypes = new List<LeaveType>
        {
             new LeaveType
           {
               Id = 1,
               DefaultDays = 21, 
               Name = "Vacation",
               CreatedBy = "jj",
               LastModifiedBy = "Anybody",
               LastModifiedDate = DateTime.Now },
                new LeaveType
           {
               Id = 2,
               DefaultDays = 3,
               Name = "Vacation",
               CreatedBy = "Me",
               LastModifiedBy = "Somebody",
               LastModifiedDate = DateTime.Now },

 new LeaveType
           {
               Id = 3,
               DefaultDays = 10,
               Name = "Sick",
               CreatedBy = "You",
               LastModifiedBy = "Nobody",
               LastModifiedDate = DateTime.Now },
    };


    var mockRepo = new Mock<ILeaveTypeRepositories>();
    mockRepo.Setup(r => r.GetAll()).ReturnAsync(leaveTypes);
    mockRepo.Setup(r => r.Add(It.ISAny<LeaveType>())).ReturnAsync((LeaveType leaveTypes)
    => {
        leaveTypes.Add(leaveType);
        return GetLeaveTypeRepository;
    });

    return mockRepo;

    }

}
