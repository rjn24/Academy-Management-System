import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CourseService } from '../services/course.service';

@Component({
  selector: 'app-courses',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './courses.component.html'
})
export class CoursesComponent implements OnInit {

  courses: any[] = [];
  model: any = {};
  editing = false;
  showTable = false;

  constructor(private courseService: CourseService) {}

  ngOnInit(): void {
    this.loadCourses();
  }

  loadCourses() {
    this.courseService.getCourses().subscribe(data => {
      this.courses = data;
    });
  }

  saveCourse() {
    if (this.editing) {
      this.courseService.updateCourse(this.model.courseCode, this.model)
        .subscribe(() => {
          this.reset();
          this.loadCourses();
        });
    } else {
      this.courseService.addCourse(this.model)
        .subscribe(() => {
          this.reset();
          this.loadCourses();
        });
    }
  }

  editCourse(course: any) {
    this.model = { ...course };
    this.editing = true;
  }

  deleteCourse(code: string) {
    this.courseService.deleteCourse(code)
      .subscribe(() => this.loadCourses());
  }

  reset() {
    this.model = {};
    this.editing = false;
  }
}
