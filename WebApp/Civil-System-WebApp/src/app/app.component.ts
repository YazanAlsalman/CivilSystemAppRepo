
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';  
import { RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {

  title = 'Civil-System-WebApp';
  citizens = [
    {
      Id: 1,
      Name: 'John Doe',
      Nationality: 'American',
      BirthDate: new Date(1990, 4, 12),
      Gender: 'Male',
      AttachmentData: null
    },
    {
      Id: 2,
      Name: 'Jane Smith',
      Nationality: 'Canadian',
      BirthDate: new Date(1985, 7, 21),
      Gender: 'Female',
      AttachmentData: null
    },
    {
      id: 3,
      Name: 'Alice Johnson',
      Nationality: 'British',
      BirthDate: new Date(1978, 11, 5),
      Gender: 'Female',
      AttachmentData: null
    }
  ];

  ngOnInit() {
    this.getCitizenData();
  }

  constructor(private http: HttpClient) {}

  
  editCitizen(citizen: any) {
    console.log('Edit:', citizen);
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


  addEditCitizen(citizen: any) {
    this.http.post('http://localhost:5032/api/Citizen/AddEditCitizenData', citizen)
      .subscribe(
        (response) => {
          console.log('Citizen added/edited successfully:', response);
        },
        (error) => {
          console.error('Error adding/editing citizen:', error);
        }
      );
  }
  

  deleteCitizen(citizenId: number) {
    this.http.delete(`http://localhost:5032/api/Citizen/DeleteCitizen?CitizenId=${citizenId}`)
      .subscribe(
        (response) => {
          console.log('Citizen deleted successfully:', response);
        },
        (error) => {
          console.error('Error deleting citizen:', error);
        }
      );
  }


}
