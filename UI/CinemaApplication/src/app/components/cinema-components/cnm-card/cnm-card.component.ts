import { Component, OnInit, Input, ContentChild, TemplateRef } from '@angular/core';

@Component({
  selector: 'app-cnm-card',
  templateUrl: './cnm-card.component.html'
})
export class CnmCardComponent implements OnInit {
  
  @ContentChild('detailTemplate', { static: false }) detailTemplate: TemplateRef<any>;
  @Input() movieName: string;
  @Input() duration: number;
  @Input() genre: string;
  @Input() imagePath: string;
  @Input() movieId:number;
  constructor() { }

  ngOnInit(): void {
  }
}
