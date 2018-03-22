import { Component, ElementRef } from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from "@angular/forms";

@Component({
	inputs: ["type"],
	providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppInputComponent, multi: true }],
	selector: "app-input",
	templateUrl: "./input.component.html"
})
export class AppInputComponent implements ControlValueAccessor
{
	constructor(private readonly el: ElementRef)
	{
		this.required = el.nativeElement.attributes["required"];
	}

	onChange(value: any) { this.writeValue(value); }

	registerOnChange(fn: any): void { this.onChange = fn; }

	registerOnTouched(fn: any): void { }

	required: any;

	setDisabledState(isDisabled: boolean): void { }

	type: string;

	value: any;

	writeValue(obj: any): void { this.value = obj; }
}