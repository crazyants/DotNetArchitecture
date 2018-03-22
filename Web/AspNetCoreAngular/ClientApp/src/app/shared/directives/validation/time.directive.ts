import { Directive, ElementRef, EventEmitter, Output } from "@angular/core";

import * as CleaveTime from "cleave.js";

@Directive({ selector: "[time]", host: { '(input)': "onInput($event)" } })
export class TimeDirective
{
	constructor(private elementRef: ElementRef)
	{
		if (!elementRef.nativeElement.classList.contains(elementRef.nativeElement.name))
		{
			elementRef.nativeElement.classList.add(elementRef.nativeElement.name);
		}

		this.onInit();
	}

	cleaveTime: any;

	@Output() ngModelChange = new EventEmitter();

	onInit()
	{
		//setTimeout(x => { this.cleaveTime = new CleaveTime(`.${this.elementRef.nativeElement.name}`, {}); }, 0);
	}

	onInput($event)
	{
		//this.cleaveTime.onChange();
		//this.ngModelChange.emit($event.target.value);
	}
}





//import { Directive, ElementRef, EventEmitter, Input, Output } from "@angular/core";

//import Cleave from "cleave.js";

//@Directive({ selector: "[time]", host: { '(input)': "onInput($event)" } })
//export class TimeDirective
//{
//	constructor(private readonly elementRef: ElementRef)
//	{
//		if (!elementRef.nativeElement.classList.contains(elementRef.nativeElement.name))
//		{
//			elementRef.nativeElement.classList.add(elementRef.nativeElement.name);
//		}
//	}

//	@Output() ngModelChange = new EventEmitter();

//	onInput($event)
//	{
//		this.ngModelChange.emit($event.target.value);
//	}
//}