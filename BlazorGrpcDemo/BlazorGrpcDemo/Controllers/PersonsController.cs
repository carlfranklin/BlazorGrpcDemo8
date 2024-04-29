﻿using BlazorGrpcDemo.Client;
using BlazorGrpcDemo.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlazorGrpcDemo.Controllers;

[Route("[controller]")]
[ApiController]
public class PersonsController : Controller
{
    PersonsManager personsManager;

    public PersonsController(PersonsManager _personsManager)
    {
        personsManager = _personsManager;
    }

    [HttpGet]
    public List<Person> GetAll()
    {
        return personsManager.People;
    }

    [HttpGet("{Id}/getbyid")]
    public Person GetPersonById(int Id)
    {
        return (from x in personsManager.People
                where x.Id == Id
                select x).FirstOrDefault();
    }
}
