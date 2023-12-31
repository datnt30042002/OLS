﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Courses.Admin;
using OLS.DTO.Users.Admin;
using OLS.Services.Implementations.Admin;
using OLS.Services.Interface.Admin;

namespace OLS._1.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseManagerController : ControllerBase
    {
        private readonly ICourseManagerRepository courseManagerRepo;
        public CourseManagerController(ICourseManagerRepository courseManagerRepo)
        {
            this.courseManagerRepo = courseManagerRepo;
        }

        // Get all courses
        [HttpGet("/getAllCourses")]
        public async Task<ActionResult<IEnumerable<CourseReadAminDTO>>> GetAllCourses()
        {
            try
            {
                var courses = await courseManagerRepo.GetAllCourses();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get course detail by CourseId
        [HttpGet("/getCourseByCourseId")]
        public async Task<ActionResult<IEnumerable<CourseReadAminDTO>>> GetCourseByCourseId(int courseId)
        {
            try
            {
                var course = await courseManagerRepo.GetCourseByCourseId(courseId);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create new course
        [HttpPost("/createCourse")]
        public async Task<ActionResult<IEnumerable<CourseCreateAminDTO>>> CreateCourse(CourseCreateAminDTO course)
        {
            try
            {
                var newCourse = await courseManagerRepo.CreateCourse(course);
                return Ok(newCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update course by CourseId
        [HttpPut("/updateCourseByCourseId")]
        public async Task<ActionResult<IEnumerable<CourseUpdateAminDTO>>> UpdateCourseByCourseId(int courseId, CourseUpdateAminDTO course)
        {
            try
            {
                var updatedCourse = await courseManagerRepo.UpdateCourseByCourseId(courseId, course);
                return Ok(updatedCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete course by CourseId
        [HttpDelete("/deleteCourseByCourseId")]
        public async Task<ActionResult> DeleteCourseByCourseId(int courseId)
        {
            try
            {
                var deletedCourse = await courseManagerRepo.DeleteCourseByCourseId(courseId);
                return NoContent(); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Search courses by CourseName
        // Task<List<CourseReadAminDTO>> SearchCoursesByCourseName(string keyword)
        [HttpGet("/searchCoursesByCourseName_Admin")]
        public async Task<ActionResult<IEnumerable<CourseReadAminDTO>>> SearchCoursesByCourseName(string keyword)
        {
            try
            {
                var searchedCourses = await courseManagerRepo.SearchCoursesByCourseName(keyword);
                return Ok(searchedCourses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Filter courses by LearningPath
        [HttpGet("/filterCoursesByLearningPath")]
        public async Task<ActionResult<IEnumerable<CourseReadAminDTO>>> FilterCoursesByLearningPath(string learningPath)
        {
            try
            {
                var filteredCourses = await courseManagerRepo.FilterCoursesByLearningPath(learningPath); 
                return Ok(filteredCourses);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Get all courses with pagination
        [HttpGet("/getAllCoursesWithPagination")]
        public async Task<ActionResult<IEnumerable<CourseReadAminDTO>>> GetAllCoursesWithPagination(int pageIndex = 1, int pageSize = 3)
        {
            try
            {
                var courses = await courseManagerRepo.GetAllCoursesWithPagination(pageIndex, pageSize);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/getNextPage")]
        public async Task<ActionResult<IEnumerable<CourseReadAminDTO>>> GetNextPage(int pageIndex = 1, int pageSize = 3)
        {
            try
            {
                var courses = await courseManagerRepo.GetNextPage(pageIndex, pageSize);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get previous page of courses
        [HttpGet("/getPreviousPage")]
        public async Task<ActionResult<IEnumerable<CourseReadAminDTO>>> GetPreviousPage(int pageIndex = 1, int pageSize = 3)
        {
            try
            {
                var courses = await courseManagerRepo.GetPreviousPage(pageIndex, pageSize);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
