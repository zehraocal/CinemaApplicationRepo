import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-cnm-card',
  templateUrl: './cnm-card.component.html',
  styleUrls: ['./cnm-card.component.css']
})
export class CnmCardComponent implements OnInit {

  @Input() movieName: string;
  @Input() duration: number;
  @Input() genre: string;
  @Input() description: string;
  
  constructor() { }

  ngOnInit(): void {
  }
}
