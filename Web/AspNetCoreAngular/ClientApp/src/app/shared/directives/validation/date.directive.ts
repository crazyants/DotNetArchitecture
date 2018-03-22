import { Directive, ElementRef, EventEmitter, Output } from "@angular/core";

import * as CleaveDate from "cleave.js";

@Directive({ selector: "[date]", host: { '(input)': "onInput($event)" } })
export class DateDirective
{
	constructor(private elementRef: ElementRef)
	{
		if (!elementRef.nativeElement.classList.contains(elementRef.nativeElement.name))
		{
			elementRef.nativeElement.classList.add(elementRef.nativeElement.name);
		}

		this.onInit();
	}

	cleaveDate: any;

	@Output() ngModelChange = new EventEmitter();

	onInit()
	{
		setTimeout(x =>
		{
			this.cleaveDate = new CleaveDate(`.${this.elementRef.nativeElement.name}`, { date: true, datePattern: ["d", "m", "Y"] });
		}, 0);
	}

	onInput($event)
	{
		this.cleaveDate.onChange();
		this.ngModelChange.emit($event.target.value);
	}
}