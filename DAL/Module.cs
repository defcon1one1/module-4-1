﻿namespace module_4_1.DAL
{


    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}