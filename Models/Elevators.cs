using System;



public class Elevators
{
    public long id { get; set; }
    public long column_id { get; set; }
    public long serial_number { get; set; }
    public string model {get; set;}
    public string building_type {get; set;}
    public string status {get; set;}
    public DateTime date_service_since {get; set;}
    public DateTime date_last_inspection {get; set;}
    public string inspection_certificate {get; set;}
    public string information {get; set;}
    public string notes {get; set;}
    public DateTime created_at {get; set;}
    public DateTime updated_at {get; set;}

}