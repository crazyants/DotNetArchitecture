import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { Option } from "../../shared/models/option.model";
import { FormChildModel, FormModel } from "./form.model";

@Component({ selector: "app-form", templateUrl: "./form.component.html" })
export class FormComponent
{
	disabled: boolean = false;
	model: FormModel;
	options: Option[];
	reactiveForm: FormGroup;

	constructor(private readonly formBuilder: FormBuilder)
	{
		this.createOptions();
		this.createModel();
		this.createReactiveForm();
	}

	createOptions()
	{
		this.options = new Array<Option>();

		for (let i = 1; i <= 10; i++)
		{
			this.options.push(new Option(`Option ${i}`, i));
		}
	}

	createModel()
	{
		this.model = new FormModel();
		this.model.child = new FormChildModel();
	}

	createReactiveForm()
	{
		this.reactiveForm = this.formBuilder.group({
			number: [],
			string: [],
			child: this.formBuilder.group({
				string: []
			})
		});
	}

	templateFormSubmit(form)
	{

	}

	templateFormSearch()
	{

	}

	reactiveFormSubmit(form)
	{

	}

	reactiveFormsSearch()
	{
	}
}