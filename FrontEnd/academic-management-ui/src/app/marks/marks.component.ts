import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MarksService } from '../services/marks.service';

@Component({
  selector: 'app-marks',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './marks.component.html'
})
export class MarksComponent implements OnInit {

  // ✅ Data list for table
  marksList: any[] = [];

  // ✅ Form model
  model: any = {};

  // ✅ UI state
  showTable = false;

  constructor(private marksService: MarksService) {}

  ngOnInit(): void {
    this.loadMarks();
  }

  // 🔹 Load all marks
  loadMarks() {
    this.marksService.getMarks().subscribe({
      next: data => this.marksList = data,
      error: err => console.error('Marks load error', err)
    });
  }

  // 🔹 Add marks
  saveMarks() {
    this.marksService.addMarks(this.model).subscribe({
      next: () => {
        this.model = {};
        this.loadMarks();
        this.showTable = true;
      },
      error: err => console.error('Save marks error', err)
    });
  }

  // 🔹 Delete marks
  deleteMarks(id: number) {
    this.marksService.deleteMarks(id).subscribe({
      next: () => this.loadMarks(),
      error: err => console.error('Delete marks error', err)
    });
  }
}
