// xVal.jquery.validate.js
// An xVal plugin to enable support for jQuery Validate
// http://xval.codeplex.com/
// (c) 2009 Steven Sanderson
// License: Microsoft Public License (Ms-PL) (http://www.opensource.org/licenses/ms-pl.html)

var xVal = xVal || {
    Plugins: {},
    AttachValidator: function(elementPrefix, rulesConfig, pluginName) {
        if (pluginName != null)
            this.Plugins[pluginName].AttachValidator(elementPrefix, rulesConfig);
        else
            for (var key in this.Plugins) {
                this.Plugins[key].AttachValidator(elementPrefix, rulesConfig);
                return;
            }
    }
};

(function($) {
    xVal.Plugins["jquery.validate"] = {
        AttachValidator: function(elementPrefix, rulesConfig) {
            this._ensureCustomFunctionsRegistered();
            for (var i = 0; i < rulesConfig.Fields.length; i++) {
                var fieldName = rulesConfig.Fields[i].FieldName;
                var fieldRules = rulesConfig.Fields[i].FieldRules;

                // Is there a matching DOM element?
                var elemId = (elementPrefix ? elementPrefix + "." : "") + fieldName;
                var elem = document.getElementById(elemId);

                if (elem) {
                    for (var j = 0; j < fieldRules.length; j++) {
                        var ruleName = fieldRules[j].RuleName;
                        var ruleParams = fieldRules[j].RuleParameters;
                        var errorText = (typeof (fieldRules[j].Message) == 'undefined' ? null : fieldRules[j].Message);
                        this._attachRuleToDOMElement(ruleName, ruleParams, errorText, $(elem));
                    }
                }
            }
        },

        _attachRuleToDOMElement: function(ruleName, ruleParams, errorText, element) {
            var parentForm = element.parents("form");
            if (parentForm.length != 1)
                alert("Error: Element " + element.attr("id") + " is not in a form");
            this._ensureFormIsMarkedForValidation($(parentForm[0]));
            this._associateNearbyValidationMessageSpanWithElement(element);

            var options = {};

            switch (ruleName) {
                case "Required":
                    options.required = true;
                    if (errorText != null) options.messages = { required: errorText };
                    break;

                case "Range":
                    if (ruleParams.Type == "string") {
                        options.xVal_stringRange = [ruleParams.Min, ruleParams.Max];
                        if (errorText != null) options.messages = { xVal_stringRange: errorText };
                    }
                    else if (ruleParams.Type == "datetime") {
                        var minDate, maxDate;
                        if (typeof (ruleParams.MinYear) != 'undefined')
                            minDate = new Date(ruleParams.MinYear, ruleParams.MinMonth - 1, ruleParams.MinDay, ruleParams.MinHour, ruleParams.MinMinute, ruleParams.MinSecond);
                        if (typeof (ruleParams.MaxYear) != 'undefined')
                            maxDate = new Date(ruleParams.MaxYear, ruleParams.MaxMonth - 1, ruleParams.MaxDay, ruleParams.MaxHour, ruleParams.MaxMinute, ruleParams.MaxSecond);
                        options.xVal_dateRange = [minDate, maxDate];
                        if (errorText != null) options.messages = { xVal_dateRange: errorText };
                    }
                    else if (typeof (ruleParams.Min) == 'undefined') {
                        options.max = ruleParams.Max;
                        if (errorText != null) options.messages = { max: errorText };
                    }
                    else if (typeof (ruleParams.Max) == 'undefined') {
                        options.min = ruleParams.Min;
                        if (errorText != null) options.messages = { min: errorText };
                    }
                    else {
                        options.range = [ruleParams.Min, ruleParams.Max];
                        if (errorText != null) options.messages = { range: errorText };
                    }

                    break;

                case "StringLength":
                    if (typeof (ruleParams.MinLength) == 'undefined') {
                        options.maxlength = ruleParams.MaxLength;
                        if (errorText != null) options.messages = { maxlength: errorText };
                    }
                    else if (typeof (ruleParams.MaxLength) == 'undefined') {
                        options.minlength = ruleParams.MinLength;
                        if (errorText != null) options.messages = { minlength: errorText };
                    }
                    else {
                        options.rangelength = [ruleParams.MinLength, ruleParams.MaxLength];
                        if (errorText != null) options.messages = { rangelength: errorText };
                    }
                    break;

                case "DataType":
                    switch (ruleParams.Type) {
                        case "EmailAddress":
                            options.email = true;
                            if (errorText != null) options.messages = { email: errorText };
                            break;
                        case "Integer":
                            options.xVal_regex = ["^\\-?\\d+$", ""];
                            options.messages = { xVal_regex: errorText || "Please enter a whole number." };
                            break;
                        case "Decimal":
                            options.number = true;
                            if (errorText != null) options.messages = { number: errorText };
                            break;
                        case "Date":
                            options.date = true;
                            if (errorText != null) options.messages = { date: errorText };
                            break;
                        case "DateTime":
                            options.xVal_regex = ["^\\d{1,2}/\\d{1,2}/(\\d{2}|\\d{4})\\s+\\d{1,2}\\:\\d{2}(\\:\\d{2})?$", ""];
                            options.messages = { xVal_regex: errorText || "Please enter a valid date and time." };
                            break;
                        case "Currency":
                            options.xVal_regex = ["^\\D?\\s?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$", ""];
                            options.messages = { xVal_regex: errorText || "Please enter a currency value." };
                            break;
                        case "CreditCardLuhn":
                            options.xVal_creditCardLuhn = true;
                            if (errorText != null) options.messages = { xVal_creditCardLuhn: errorText };
                            break;
                    }
                    break;

                case "RegEx":
                    options.xVal_regex = [ruleParams.Pattern, ruleParams.Options];
                    if (errorText != null) options.messages = { xVal_regex: errorText };
                    break;
            }

            element.rules("add", options);
        },

        _associateNearbyValidationMessageSpanWithElement: function(element) {
            // If there's a <span class='field-validation-error'> soon after, it's probably supposed to display the error message
            // jquery.validation goes looking for attributes called "htmlfor" and "generated", set as follows
            var nearbyMessages = element.nextAll("span.field-validation-error");
            if (nearbyMessages.length > 0) {
                $(nearbyMessages[0]).attr("generated", "true")
                                    .attr("htmlfor", element.attr("id"));
            }
        },

        _ensureFormIsMarkedForValidation: function(formElement) {
            if (!formElement.data("isMarkedForValidation")) {
                formElement.data("isMarkedForValidation", true);
                formElement.validate({
                    errorClass: "field-validation-error",
                    errorElement: "span",
                    highlight: function(element) { $(element).addClass("input-validation-error"); },
                    unhighlight: function(element) { $(element).removeClass("input-validation-error"); }
                });
            }
        },

        _ensureCustomFunctionsRegistered: function() {
            if (!jQuery.validator.xValFunctionsRegistered) {
                jQuery.validator.xValFunctionsRegistered = true;

                jQuery.validator.addMethod("xVal_stringRange", function(value, element, params) {
                    if (this.optional(element)) return true;
                    if (params[0] != null)
                        if (value < params[0]) return false;
                    if (params[1] != null)
                        if (value > params[1]) return false;
                    return true;
                }, function(params) {
                    if ((params[0] != null) && (params[1] != null))
                        return "Please enter a value alphabetically between '" + params[0] + "' and '" + params[1] + "'.";
                    else if (params[0] != null)
                        return "Please enter a value not alphabetically before '" + params[0] + "'.";
                    else
                        return "Please enter a value not alphabetically after '" + params[1] + "'.";
                });

                jQuery.validator.addMethod("xVal_dateRange", function(value, element, params) {
                    if (this.optional(element)) return true;

                    var parsedValue = Date.parse(value);
                    if (isNaN(parsedValue))
                        return false;
                    else
                        parsedValue = new Date(parsedValue);
                    if (params[0] != null)
                        if (parsedValue < params[0]) return false;
                    if (params[1] != null)
                        if (parsedValue > params[1]) return false;
                    return true;
                }, function(params, elem) {
                    if (isNaN(Date.parse(elem.value)))
                        return "Please enter a valid date in yyyy/mm/dd format.";
                    var formatDate = function(date) {
                        var result = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDay();
                        if (date.getHours() + date.getMinutes() + date.getSeconds() != 0)
                            result += " " + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
                        return result.replace(/\b(\d)\b/g, '0$1');
                    };
                    if ((params[0] != null) && (params[1] != null))
                        return "Please enter a date between " + formatDate(params[0]) + " and " + formatDate(params[1]) + ".";
                    else if (params[0] != null)
                        return "Please enter a date no earlier than " + formatDate(params[0]) + ".";
                    else
                        return "Please enter a date no later than " + formatDate(params[1]) + ".";
                });

                jQuery.validator.addMethod("xVal_regex", function(value, element, params) {
                    if (this.optional(element)) return true;
                    var pattern = params[0];
                    var options = params[1];
                    var regex = new RegExp(pattern, options);
                    return regex.test(value);
                }, function(params) {
                    return "Please enter a valid value."; // Pity we can't be more descriptive
                });

                jQuery.validator.addMethod("xVal_creditCardLuhn", function(value, element, params) {
                    if (this.optional(element)) return true;
                    value = value.replace(/\D/g, "");
                    if (value == "") return false;
                    var sum = 0;
                    for (var i = value.length - 2; i >= 0; i -= 2)
                        sum += Array(0, 2, 4, 6, 8, 1, 3, 5, 7, 9)[parseInt(value.charAt(i), 10)];
                    for (var i = value.length - 1; i >= 0; i -= 2)
                        sum += parseInt(value.charAt(i), 10);
                    return (sum % 10) == 0;
                }, function(params) {
                    return "Please enter a valid credit card number.";
                });
            }
        }
    };
})(jQuery);
