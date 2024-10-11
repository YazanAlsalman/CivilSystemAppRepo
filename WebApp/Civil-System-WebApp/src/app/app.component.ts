
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';  
import { RouterOutlet } from '@angular/router';
import { CitizenComponent } from '../CivilComponents/citizenViewer.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, HttpClientModule,CitizenComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {

  title = 'Civil-System-WebApp';


  ngOnInit() {
  }

  constructor(private http: HttpClient) {}




}
