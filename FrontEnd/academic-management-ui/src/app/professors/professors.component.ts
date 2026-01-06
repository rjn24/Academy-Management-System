import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ProfessorService } from '../services/professor.service';

@Component({
  selector: 'app-professors',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './professors.component.html'
})
export class ProfessorsComponent implements OnInit {

  professors: any[] = [];
  model: any = {};
  editing = false;
  showTable = false;  
  constructor(private professorService: ProfessorService) {}

  ngOnInit(): void {
    this.loadProfessors();
  }

  loadProfessors() {
    this.professorService.getProfessors()
      .subscribe(data => this.professors = data);
  }

  saveProfessor() {
    if (this.editing) {
      this.professorService.updateProfessor(this.model.professorID, this.model)
        .subscribe(() => {
          this.reset();
          this.loadProfessors();
        });
    } else {
      this.professorService.addProfessor(this.model)
        .subscribe(() => {
          this.reset();
          this.loadProfessors();
        });
    }
  }

  editProfessor(p: any) {
    this.model = { ...p };
    this.editing = true;
  }

  deleteProfessor(id: number) {
    this.professorService.deleteProfessor(id)
      .subscribe(() => this.loadProfessors());
  }

  reset() {
    this.model = {};
    this.editing = false;
  }
}
