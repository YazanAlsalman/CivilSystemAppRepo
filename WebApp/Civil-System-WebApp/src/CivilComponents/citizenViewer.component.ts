import { Component } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';  
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-citizenViewer',
  standalone: true,
  imports: [HttpClientModule, CommonModule,FormsModule ],  // <-- Include necessary modules here
  templateUrl: './citizenViewer.component.html',
  styleUrls: ['./citizenViewer.component.css']
})
export class CitizenComponent {

  citizens:any[] = [];
   tempCitizen:any = {};
   addEditDialogShown = false
   operationType = 1
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getCitizenData();
  }

  getCitizenData() {
    this.http.get<any[]>('http://localhost:5032/api/Citizen/GetCitizenData')
      .subscribe(
        (data: any[]) => {
          this.citizens = data;
        },
        (error: any) => {
          console.error('Error fetching citizen data:', error);
        }
      );
  }


  showAddEditDialog(citizen: any,operationType:number) {
    if(operationType == 1){
        this.operationType == 1
        this.tempCitizen = {}
    }else if(operationType == 2){
        this.operationType == 2
        this.tempCitizen = citizen
        this.tempCitizen.birthDate = this.formatDate(this.tempCitizen.birthDate)
    }
    this.addEditDialogShown = true;
  }

  addEditCitizen(citizen: any,operationType:number) {
    
    const citizenPayload = {
         id: this.tempCitizen.id,
          name: this.tempCitizen.name,
          nationality: this.tempCitizen.nationality,
          birthDate: this.tempCitizen.birthDate,
          gender: this.tempCitizen.gender,
        attachmentData: this.tempCitizen.attachmentData
      };

    this.http.post('http://localhost:5032/api/Citizen/AddEditCitizenData', citizenPayload)
      .subscribe(
        (response) => {
          console.log('Citizen added/edited successfully:', response);
          this.addEditDialogShown = false;

        },
        (error) => {
          console.error('Error adding/editing citizen:', error);
        }
      );
  }

  formatDate(dateString: string): string {
    return dateString.split('T')[0]; 
  }
  

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        this.tempCitizen.attachmentData = reader.result; 
      };
      reader.readAsDataURL(file);
    }
  }

  deleteCitizen(citizen: any) {
    this.http.delete(`http://localhost:5032/api/Citizen/DeleteCitizen?CitizenId=${citizen.id}`)
      .subscribe(
        (response) => {
          this.citizens = this.citizens.filter((c:any) => c.id !== citizen.id);
        },
        (error: any) => {
          console.error('Error deleting citizen:', error);
        }
      );
  }
}
