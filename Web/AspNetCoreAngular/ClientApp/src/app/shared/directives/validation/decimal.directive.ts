import { Directive, ElementRef, EventEmitter, Output } from "@angular/core";

import * as CleaveDecimal from "cleave.js";

@Directive({ selector: "[decimal]", host: { '(input)': "onInput($event)" } })
export class DecimalDirective
{
	constructor(private elementRef: ElementRef)
	{
		if (!elementRef.nativeElement.classList.contains(elementRef.nativeElement.name))
		{
			elementRef.nativeElement.classList.add(elementRef.nativeElement.name);
		}

		this.onInit();
	}

	cleaveDecimal: any;

	@Output() ngModelChange = new EventEmitter();

	onInit()
	{
		setTimeout(x =>
		{
			this.cleaveDecimal = new CleaveDecimal(`.${this.elementRef.nativeElement.name}`, {
				delimiter: ".",
				numeral: true,
				numeralDecimalMark: ",",
				numeralDecimalScale: 2,
				numeralIntegerScale: 20,
			});
		}, 0);
	}

	onInput($event)
	{
		this.cleaveDecimal.onChange();
		this.ngModelChange.emit($event.target.value);
	}
}