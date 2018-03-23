import { Component, ElementRef } from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from "@angular/forms";
import { Option } from "../../models/option.model";

@Component({
	inputs: ["options"],
	providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppSelectComponent, multi: true }],
	selector: "app-select",
	templateUrl: "./select.component.html"
})
export class AppSelectComponent implements ControlValueAccessor
{
	constructor(private readonly el: ElementRef)
	{
		this.required = el.nativeElement.attributes["required"];
	}

	onChange(value: any) { this.writeValue(value); }

	options: Option[];

	registerOnChange(fn: any): void { this.onChange = fn; }

	registerOnTouched(fn: any): void { }

	required: any;

	setDisabledState(isDisabled: boolean): void { }

	value: any;

	writeValue(obj: any): void { this.value = obj; }
}