using BlazorGrpcDemo.Client;
using Grpc.Core;

namespace BlazorGrpcDemo.Data;

public class PeopleService : People.PeopleBase
{
    PersonsManager _personsManager;

    public PeopleService(PersonsManager personsManager)
    {
        _personsManager = personsManager;
    }

    public override Task<PeopleReply> GetAll(GetAllPeopleRequest request,
        ServerCallContext context)
    {
        var reply = new PeopleReply();
        reply.People.AddRange(_personsManager.People);
        return Task.FromResult(reply);
    }

    public override Task<Person> GetPersonById(GetPersonByIdRequest request,
        ServerCallContext context)
    {
        var result = (from x in _personsManager.People
                      where x.Id == request.Id
                      select x).FirstOrDefault();
        return Task.FromResult(result);
    }
}