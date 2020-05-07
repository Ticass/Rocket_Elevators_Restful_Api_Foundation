using System;



public class Leads
{
    public long id { get; set; }
    public string full_name { get; set; }
    public string email {get; set;}
    public string phone {get; set;}
    public string project_name {get; set;}
    public string project_description {get; set;}
    public string department {get; set;}
    public string message {get; set;}
    public DateTime created_at {get; set;}
    public DateTime updated_at {get; set;}
    public byte[] file_attachment {get; set;}
    public string file_name {get; set;}
    public long? customer_id { get; set; }


}