using System;



public class Batteries
{
    public long id { get; set; }
    public long building_id { get; set; }
    public long employee_id  { get; set; }
    public string building_type {get; set;}
    public string status {get; set;}
    public DateTime date_service_since {get; set;}
    public DateTime date_last_inspection {get; set;}
    public string operations_certificate {get; set;}
    public string information {get; set;}
    public string notes {get; set;}


}