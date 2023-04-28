namespace HR.LeaveManagement.UnitTests.LeaveTypes.Queries;

public class GetLeaveTypeListRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mocks<ILeaveTypeRepository> _mockRepo;

    public GetLeaveTypeListRequestHandlerTests(){
        _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(
            c => {
                c.AddProfile<MappingPRofile>();
                });

                _mapper = mapperConfig.CreateMapper();

    }

    [Fact]
    public async Task GetLeaveTypeListTest(){
        var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);
        var result = await handler.Handler(
            new GetLeaveTypeListRequest(), CancellationToken.None
        );

        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(3);
    }

}
