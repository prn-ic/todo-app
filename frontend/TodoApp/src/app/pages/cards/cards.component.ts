import { Component } from "@angular/core";
import { CardItem } from "./models/card.model";
import { NgFor, NgClass } from "@angular/common";
import {DatePipe} from '@angular/common';

@Component({
  selector: 'task-cards',
  templateUrl: './cards.component.html',
  styleUrl: './cards.component.scss',
  imports: [NgFor, DatePipe, NgClass],
  standalone: true
})

export class CardsComponent {
  title = "My tasks"
  public cardItems: CardItem[] = [new CardItem("tempTitle", "tempasdfasdfasdfasdfasfsadfsadfsafasdDescription", new Date(), "notdone")];
}
