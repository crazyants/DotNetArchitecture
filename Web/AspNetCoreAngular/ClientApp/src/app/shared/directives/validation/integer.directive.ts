import { Directive, ElementRef, EventEmitter, Output } from "@angular/core";

import * as CleaveInteger from "cleave.js";

@Directive({ selector: "[integer]", host: { '(input)': "onInput($event)" } })
export class IntegerDirective
{
	constructor(private elementRef: ElementRef)
	{
		if (!elementRef.nativeElement.classList.contains(elementRef.nativeElement.name))
		{
			elementRef.nativeElement.classList.add(elementRef.nativeElement.name);
		}

		this.onInit();
	}

	cleaveInteger: any;

	@Output() ngModelChange = new EventEmitter();

	onInit()
	{
		setTimeout(x => { this.cleaveInteger = new CleaveInteger(`.${this.elementRef.nativeElement.name}`, { blocks: [20], numericOnly: true }); }, 0);
	}

	onInput($event)
	{
		this.cleaveInteger.onChange();
		this.ngModelChange.emit($event.target.value);
	}
}